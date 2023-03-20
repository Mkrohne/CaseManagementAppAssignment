using CaseManagementApp.Contexts;
using CaseManagementApp.Models;
using CaseManagementApp.Models.Entities;

namespace CaseManagementApp.Services
{
    public class CaseService
    {
        private readonly DataContext _dataContext;

        public CaseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCase(CaseEntity newCase)
        {
            newCase.Status = "Nytt";
            _dataContext.Cases.Add(newCase);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddUser(User newUser)
        {
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,

            };

            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<CaseEntity> GetAllCases()
        {
            return _dataContext.Cases.ToList();
        }

        public CaseEntity GetCaseById(int id)
        {
            return _dataContext.Cases.SingleOrDefault(c => c.CaseId == id);
        }

        public async Task UpdateCase(CaseEntity updatedCase)
        {
            var existingCase = GetCaseById(updatedCase.CaseId);
            if (existingCase == null)
            {
                throw new ArgumentException($"Kan inte hitta ärende med ID: {updatedCase.CaseId}");
            }

            existingCase.Title = updatedCase.Title;
            existingCase.Description = updatedCase.Description;
            existingCase.Status = updatedCase.Status;
            existingCase.UpdatedAt = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteCase(int id)
        {
            var existingCase = GetCaseById(id);
            if (existingCase == null)
            {
                throw new ArgumentException($"Kan inte hitta ärende med ID: {id}");
            }

            _dataContext.Cases.Remove(existingCase);
            await _dataContext.SaveChangesAsync();
        }
    }
}
