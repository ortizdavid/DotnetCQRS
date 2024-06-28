namespace DotnetCQRS.Helpers
{
    public class FileUploader
    {
        public string DestinationPath { get; }
        public string[] AllowedExtensions { get; }
        public long MaxSize { get; }

        public FileUploader(string? destinationPath, string[] allowedExtensions, long maxSize)
        {
            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException("DestinationPath cannot be null");
            }
            DestinationPath = destinationPath;
            AllowedExtensions = allowedExtensions;
            MaxSize = maxSize;
        }

        public async Task<UploadInfo> UploadSingleFile(HttpRequest request, string fileField)
        {
            var file = request.Form.Files.GetFile(fileField);
            if (file == null)
            {
                throw new ArgumentException("File not found in request.");
            }
            // Validate file size
            if (file.Length > MaxSize)
            {
                throw new ArgumentException($"File too large. Maximum allowed size: {MaxSize / 1024 / 1024}MB");
            }
            // Get file extension and validate
            var fileExt = Path.GetExtension(file.FileName);
            if (!IsValidExtension(fileExt))
            {
                throw new ArgumentException($"Invalid file extension. Allowed extensions: {string.Join(", ", AllowedExtensions)}");
            }
            var fileName = GenerateUniqueFileName(file.FileName);
            // Save the file
            await SaveUploadedFile(file, fileName);
            // Build UploadInfo
            return new UploadInfo
            {
                OriginalFileName = file.FileName,
                FinalName = fileName,
                Size = file.Length,
                ContentType = file.ContentType,
                Extension = fileExt,
                UploadTime = DateTime.Now
            };
        }


        public async Task<List<UploadInfo>> UploadMultipleFiles(HttpContext context, string formFile)
        {
            context.Request.EnableBuffering(); // Enable buffering to allow multiple reads of the request body
            var uploadInfos = new List<UploadInfo>();
            var formCollection = await context.Request.ReadFormAsync();
            var files = formCollection.Files.GetFiles(formFile);

            foreach (var file in files)
            {
                if (file.Length == 0)
                {
                    continue;
                }
                using (var stream = file.OpenReadStream())
                {
                    // Validate file size
                    if (file.Length > MaxSize)
                    {
                        throw new Exception($"File '{file.FileName}' is too large. Must be smaller than {MaxSize} bytes");
                    }
                    // Get file extension and validate
                    var fileExt = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!IsValidExtension(fileExt))
                    {
                        throw new Exception($"File '{file.FileName}' has an invalid extension. Allowed: {string.Join(", ", AllowedExtensions)}");
                    }
                    // Generate unique filename
                    var fileName = GenerateUniqueFileName(file.FileName);
                    // Save the file
                    await SaveUploadedFile(stream, fileName);
                    // Build UploadInfo
                    var uploadInfo = new UploadInfo
                    {
                        OriginalFileName = file.FileName,
                        FinalName = fileName,
                        Size = file.Length,
                        ContentType = file.ContentType,
                        Extension = fileExt,
                        UploadTime = DateTime.Now,
                    };
                    uploadInfos.Add(uploadInfo);
                }
            }
            return uploadInfos;
        }
      

        private bool IsValidExtension(string? extension)
        {
            return AllowedExtensions.Contains(extension);
        }

        private string GenerateUniqueFileName(string fileName)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        }

        private async Task SaveUploadedFile(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(DestinationPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        private async Task SaveUploadedFile(Stream stream, string fileName)
        {
            var filePath = Path.Combine(DestinationPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

    }

    public class UploadInfo
    {
        public string? OriginalFileName { get; set; }
        public string? FinalName { get; set; }
        public long Size { get; set; }
        public string? ContentType { get; set; }
        public string? Extension { get; set; }
        public DateTime UploadTime { get; set; }
    }

}