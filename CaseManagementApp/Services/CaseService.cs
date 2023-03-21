using CaseManagementApp.Contexts;
using CaseManagementApp.Models;
using CaseManagementApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementApp.Services
{
    public class CaseService
    {
        private readonly DataContext _dataContext;

        public CaseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCase(Case newCase)
        {

            CaseEntity entity = new CaseEntity();

            entity.Title = newCase.Title;
            entity.Description = newCase.Description;
            entity.Status = newCase.Status;           
            entity.CreatedBy = newCase.CreatedBy;
            entity.CreationDate = newCase.CreationDate;

            var _userEntity = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == newCase.Email);
            if (_userEntity != null)
                entity.UserId = _userEntity.Id;
            else
                entity.User = new UserEntity 
                {
                    FirstName = newCase.FirstName,
                    LastName = newCase.LastName,
                    Email = newCase.Email,
                    PhoneNumber = newCase.PhoneNumber,
                };

            _dataContext.Cases.AddAsync(entity);
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
