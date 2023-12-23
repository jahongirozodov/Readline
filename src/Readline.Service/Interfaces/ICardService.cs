using Readline.Service.DTOs.Cards;

namespace Readline.Service.Interfaces;

public interface ICardService
{
    Task<CardResultDto> AddAsync(CardCreationDto dto);

}
