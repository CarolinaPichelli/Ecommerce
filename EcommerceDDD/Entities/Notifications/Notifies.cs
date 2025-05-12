// Importa namespaces necessários
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    // Classe usada para representar notificações de validação
    public class Notifies
    {
        // Construtor: inicializa a lista de notificações
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        // [NotMapped] indica que essa propriedade não será mapeada para uma coluna no banco de dados
        [NotMapped]
        public string NomePropriedade { get; set; } // Nome da propriedade que causou o erro

        [NotMapped]
        public string mensagem { get; set; } // Mensagem de erro associada à propriedade

        [NotMapped]
        public List<Notifies> Notitycoes; // Lista que armazena todas as notificações de erro da entidade


        // Método para validar se uma string é válida (não nula ou vazia)
        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                // Adiciona uma notificação indicando que o campo é obrigatório
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false; // Indica que a validação falhou
            }

            return true; // Validação passou
        }

        // Método para validar se um inteiro é maior que 0
        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                // Adiciona uma notificação indicando que o valor deve ser maior que zero
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        // Método para validar se um decimal é maior que 0
        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                // Adiciona uma notificação indicando que o valor deve ser maior que zero
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}
