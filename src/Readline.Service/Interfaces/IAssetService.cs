using Readline.Domain.Entites.Assets;
using Readline.Service.DTOs.Assets;

namespace Readline.Service.Interfaces;

public interface IAssetService
{
    Task<Asset> UploadAsync(AssetCreationDto dto);
    Task<bool> RemoveAsync(Asset asset);
}
