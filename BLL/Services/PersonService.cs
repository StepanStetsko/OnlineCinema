using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(PersonRepository repository)
        {
            _personRepository = repository;
        }
        public async Task<Person> ShowDetailsAsync(int seasonId)
        {
            var seasonTemp = await _personRepository.GetWhere(x => x.Id == seasonId);
            return seasonTemp.First();
        }

        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.Create(person);
        }
    }
}
