using WarehouseSystem.Domain.Abstractions;
using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Domain.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly IWarehouseRepository _repository;

        public GebruikerService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public bool EmailBestaat(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return _repository.EmailBestaat(email);
        }

        public void RegistreerGebruiker(string? naam, string? email, string? wachtwoord)
        {
            if (string.IsNullOrWhiteSpace(naam) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(wachtwoord))
                throw new ArgumentException("Naam, email en wachtwoord mogen niet leeg zijn.");

            if (EmailBestaat(email))
                throw new InvalidOperationException("Dit e-mailadres is al in gebruik.");

            _repository.RegistreerGebruiker(naam, email, wachtwoord);
        }

        public Gebruiker? Login(string? email, string? wachtwoord)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(wachtwoord))
                return null;

            return _repository.Login(email, wachtwoord);
        }
    }
}
