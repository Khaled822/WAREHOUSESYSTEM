using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Domain.Services
{
    public interface IGebruikerService
    {
        bool EmailBestaat(string? email);
        void RegistreerGebruiker(string? naam, string? email, string? wachtwoord);
        Gebruiker? Login(string? email, string? wachtwoord);
    }
}
