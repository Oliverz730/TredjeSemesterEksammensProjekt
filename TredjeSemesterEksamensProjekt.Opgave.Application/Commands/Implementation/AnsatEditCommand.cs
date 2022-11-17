using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands.Implementation
{
    public class AnsatEditCommand : IAnsatEditCommand
    {

        private readonly IAnsatRepository _ansatRepository;
        private readonly IKompetanceRepository _kompetanceRepository;

        public AnsatEditCommand(IAnsatRepository ansatRepository, IKompetanceRepository kompetanceRepository)
        {
            _ansatRepository = ansatRepository;
            _kompetanceRepository = kompetanceRepository;
        }

        void IAnsatEditCommand.Edit(AnsatEditRequestDto ansatEditRequestDto)
        {
            //Read

            var model = _ansatRepository.Load(ansatEditRequestDto.UserId);
            List<KompetanceEntity> kompetancer = new();

            foreach (var komp in ansatEditRequestDto.Kompetancer)
            {
                kompetancer.Add(_kompetanceRepository.Load(komp.Id));
              
            }


            //Do It
            model.Edit(ansatEditRequestDto.UserId, ansatEditRequestDto.Name, kompetancer);
            

            // Save

            _ansatRepository.Update(model);


        }
    }
}
