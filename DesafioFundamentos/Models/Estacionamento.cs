using System.Reflection.Metadata.Ecma335;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar (padrao LLLNLNN ou (LLLNNNN) || L: letra N:numero ) :");
            var placa = Console.ReadLine().ToUpper().Replace(" ", "");


            if (veiculos.Exists(x => x.Equals(placa))) Console.WriteLine("O carro ja esta estacionado");
            else if (VerificarPlaca(placa, out string message)) veiculos.Add(placa);
            else Console.WriteLine(message);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {


                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                decimal valorTotal = 0;
                var resposta = Console.ReadLine();
                var eValido = int.TryParse(resposta, out int horas);

                if (eValido)
                {
                    valorTotal = CalcularPreco(horas);
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Dado Inválido, Digite Apenas números");
                    RemoverVeiculo();
                }

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                RemoverVeiculo();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        /* Verica se a placa segue o padrão mercosul LLLNLNN */

        /// <summary>
        /// Retorna um booleano indicando se a placa esta correta ou não,e retorna uma mensagem caso não esteja no padrão
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool VerificarPlaca(string placa, out string message)
        {
            message = "";
            bool valida = placa.Length == 7;

            if (!valida)
            {
                message = "A placa digitada não contém a quantidade de caracteres correta (uma placa deve conter 7 caracteres)";
                return false;
            }

            for (int i = 0; i < placa.Length; i++)
            {

                if (i <= 2) valida = Char.IsLetter(placa[i]);
                else if (i == 3 || i >= 5) valida = Char.IsNumber(placa[i]);
                else if (i == 4) valida = Char.IsLetterOrDigit(placa[i]);

                if (!valida)
                {
                    message = "Placa digitada não segue o padrão: LLLNLNN ou LLLNNNN (L: letra, N: numero)";
                    return false;
                }
            }

            return valida;
        }

        public decimal CalcularPreco(int horas)
        {
            return precoInicial + precoPorHora * horas;
        }
    }
}
