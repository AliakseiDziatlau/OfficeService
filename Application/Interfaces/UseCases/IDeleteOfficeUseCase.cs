namespace OfficeService.Application.Interfaces.UseCases;

public interface IDeleteOfficeUseCase
{
    Task Execute(string id);
}