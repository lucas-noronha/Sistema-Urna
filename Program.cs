using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVotos
{
    class Program
    {
        static void Main(string[] args)
        {
            var candidato1 = new Candidato()
            {
                Nome = "Airton Sena",
                Numero = 35
            };

            var candidato2 = new Candidato()
            {
                Nome = "Nelson Mandela",
                Numero = 90
            };

            var segundoTurno = OrganizarEResultarEleicoes(candidato1, candidato2);

            while (segundoTurno == true)
            {
                segundoTurno = OrganizarEResultarEleicoes(candidato1, candidato2);
            }
            Console.ReadLine();
        }

        public static bool OrganizarEResultarEleicoes(Candidato candidato1, Candidato candidato2)
        {
            var votos = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                string titulo = $"Em quem deseja votar? {Environment.NewLine}";
                string apresentacao = titulo + $"Canditado: {candidato1.Nome} - Número: {candidato1.Numero} {Environment.NewLine}";
                apresentacao = apresentacao + $"Canditado: {candidato2.Nome} - Número: {candidato2.Numero}";

                Console.WriteLine(apresentacao);
                var voto = Console.ReadLine();
                while (int.Parse(voto) != candidato1.Numero && int.Parse(voto) != candidato2.Numero)
                {
                    Console.WriteLine("Voto invalido, vote novamente");
                    voto = Console.ReadLine();
                }
                votos.Add(voto);
            }
            var votosCandidato1 = votos.Where(x => x == "35").Count();
            var votosCandidato2 = votos.Where(x => x == "90").Count();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"O candidato {candidato1.Nome} recebeu {votosCandidato1}");
            Console.WriteLine($"O candidato {candidato2.Nome} recebeu {votosCandidato2}");
            if (votosCandidato1 > votosCandidato2)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"O vencedor foi {candidato1.Nome} com {votosCandidato1} votos");
            }
            else if (votosCandidato2 > votosCandidato1)
            {
                Console.WriteLine($"O vencedor foi {candidato2.Nome} com {votosCandidato2} votos");
            }

            else
            {
                Console.WriteLine("Os candidatos empataram, será necessário um segundo turno!");
                Console.WriteLine("Deseja realizar segundo turno? 1 = SIM, 2 = NAO");
                var segundoTurno = Console.ReadLine();
                return segundoTurno == "1" ? true : false;
            }

            return false;
        }
        
    }
}