using AutoMapper;
using Microsoft.AspNetCore.Http;
using Readline.Data.IRepositories;
using Readline.Domain.Entites.Assets;
using Readline.Service.DTOs.Assets;
using Readline.Service.Helpers;
using Readline.Service.Interfaces;

namespace Readline.Service.Services;

public class AssetService : IAssetService
{
    private readonly IMapper mapper;
    private readonly IRepository<Asset> repository;
    public AssetService(IMapper mapper, IRepository<Asset> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<Asset> UploadAsync(AssetCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "image");
        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtension = Path.GetExtension(dto.FormFIle.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var filePath = Path.Combine(webRootPath, fileExtension);

        using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            await fileStream.WriteAsync(dto.FormFIle.ToByte());
            await dto.FormFIle.CopyToAsync(fileStream);
        };

        var asset = new Asset()
        {
            FileName = fileName,
            FilePath = filePath,
        };

        await repository.CreateAsync(asset);
        await repository.SaveAsync();

        return mapper.Map<Asset>(asset);
    }
    public async Task<bool> RemoveAsync(Asset asset)
    {
        this.repository.Delete(asset);
        await this.repository.SaveAsync();
        return true;
    }
}