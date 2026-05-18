using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Domain.Abstractions
{
    public interface IWarehouseRepository
    {
        bool EmailBestaat(string? email);
        void RegistreerGebruiker(string? naam, string? email, string? wachtwoord);
        Gebruiker? Login(string? email, string? wachtwoord);
    }
}
