using EZE.ADO.NetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZE.Repositories
{
    public class ProfessorRepository
    {
        private EZEEntities5 context;
        private static ProfessorRepository instance = null;

        private ProfessorRepository() {
            context = new EZEEntities5();
        }

        public static ProfessorRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProfessorRepository();
            }
            return instance;
        }

        public ProfessorsTable getProfessorByName(string name)
        {
            ProfessorsTable professors = context.ProfessorsTables.Where(p => p.Professor == name)
                    .ToList()
                    .First();
            return professors;
        }
    }
}