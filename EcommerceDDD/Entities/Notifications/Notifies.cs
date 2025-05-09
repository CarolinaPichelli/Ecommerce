using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies() {

            Notitycoes = new List<Notifies>();
        }

        [NotMapped] //não cria tabela no banco
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string mensagem {  get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;

        public bool ValidaPropriedadeString (string valor,  string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo obrigatório",
                    NomePropriedade = NomePropriedade
                });

                return false;
            }

            return true;
        }

  

        public bool ValidaPropriedadeInt(int valor, string nomePropriedade)
        { 
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = NomePropriedade
                });

                return false;
            }

            return true;
        }

    }

        public bool ValidaPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = NomePropriedade
                });

                return false;
            }

            return true;
        }

    }
}
