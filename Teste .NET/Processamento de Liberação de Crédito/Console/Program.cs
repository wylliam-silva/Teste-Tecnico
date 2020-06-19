using Modelo;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoConsole
{
    class Program
    {
        enum TipoCredito : int
        {
            Direto = 1,
            Consignado = 2,
            PessoaJuridica = 3,
            PessoaFisica = 4,
            Imobiliario = 5
        };
        private static decimal valorCredito { get; set; }
        private static int quantidadeParcelas { get; set; }
        private static DateTime dataPrimeiroVencimento { get; set; }

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenuPrincipal();

                #region Verificar Opção Parametro Entrada Tipo de Credito
                var opcao = Console.ReadKey().KeyChar;

                Console.Clear();

                TipoCredito tipoCredito = 0;

                try
                {
                    tipoCredito = (TipoCredito)Enum.Parse(typeof(TipoCredito), opcao.ToString(), true);

                    if ((int)tipoCredito > 5)
                    {
                        Console.Clear();
                        ExibirMensagemExcecaoOpcaoMenu();
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    ExibirMensagemExcecaoOpcaoMenu();
                    continue;
                }
                #endregion

                #region Verificar Parametro de Entrada Valor Crédito
                Console.Clear();

                Console.WriteLine("Digite o valor de crédito desejado no formato '0,00' com duas casas decimais para os centavos, exemplo: 14000,56(quatorze mil e 56 centavos)");
                
                try
                {
                    var valorCreditoRL = Console.ReadLine();
                    valorCredito = Convert.ToDecimal(valorCreditoRL);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                #endregion

                #region Verificar Parametro de Entrada Parcelas
                Console.Clear();

                Console.WriteLine("Digite a quantidade de parcelas desejadas");
                
                try
                {
                    quantidadeParcelas = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                #endregion

                #region Verificar Parametro de Entrada Data Primeiro Vencimento
                Console.Clear();

                Console.WriteLine("Digite a data de vencimento da primeira parcela no formato 'dd/mm/yyyy'");
                
                try
                {
                    dataPrimeiroVencimento = Convert.ToDateTime(Console.ReadLine(), new CultureInfo("pt-BR"));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                #endregion

                ProcessarCalculoCredito(tipoCredito);
            }
        }

        private static void ProcessarCalculoCredito(TipoCredito tipoCredito)
        {
            switch (tipoCredito)
            {
                case TipoCredito.Direto:
                    ProcessarCalculoCreditoDireto();
                    break;
                case TipoCredito.Consignado:
                    ProcessarCalculoCreditoConsignado();
                    break;
                case TipoCredito.PessoaJuridica:
                    ProcessarCalculoCreditoPessoaJuridica();
                    break;
                case TipoCredito.PessoaFisica:
                    ProcessarCalculoCreditoPessoaFisica();
                    break;
                case TipoCredito.Imobiliario:
                    ProcessarCalculoCreditoImobiliario();
                    break;
                default:
                    Console.Clear();
                    ExibirMensagemExcecaoOpcaoMenu();
                    break;
            }
        }

        private static void ProcessarCalculoCreditoImobiliario()
        {
            CreditoImobiliario creditoImobiliario = new CreditoImobiliario(new Credito<CreditoImobiliario>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoImobiliario.Taxa });

            CreditoVO creditoVOImobiliario = creditoImobiliario.Calcular();

            Console.Clear();

            Console.WriteLine($"Status do Crédito: {creditoVOImobiliario.Status}\nValor Total Com Juros: R$ {creditoVOImobiliario.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOImobiliario.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessarCalculoCreditoPessoaFisica()
        {
            CreditoPessoaFisica creditoPessoaFisica = new CreditoPessoaFisica(new Credito<CreditoPessoaFisica>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoPessoaFisica.Taxa });

            CreditoVO creditoVOPessoaFisica = creditoPessoaFisica.Calcular();

            Console.Clear();

            Console.WriteLine($"Status do Crédito: {creditoVOPessoaFisica.Status}\nValor Total Com Juros: R$ {creditoVOPessoaFisica.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOPessoaFisica.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessarCalculoCreditoPessoaJuridica()
        {
            CreditoPessoaJuridica creditoPessoaJuridica = new CreditoPessoaJuridica(new Credito<CreditoPessoaJuridica>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoPessoaJuridica.Taxa });

            creditoPessoaJuridica.ValorCredito = valorCredito;

            CreditoVO creditoVOPessoaJuridica = creditoPessoaJuridica.Calcular();

            Console.Clear();

            Console.WriteLine($"Status do Crédito: {creditoVOPessoaJuridica.Status}\nValor Total Com Juros: R$ {creditoVOPessoaJuridica.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOPessoaJuridica.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessarCalculoCreditoConsignado()
        {
            CreditoConsignado creditoConsignado = new CreditoConsignado(new Credito<CreditoConsignado>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoConsignado.Taxa });

            CreditoVO creditoVOConsignado = creditoConsignado.Calcular();

            Console.Clear();

            Console.WriteLine($"Status do Crédito: {creditoVOConsignado.Status}\nValor Total Com Juros: R$ {creditoVOConsignado.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOConsignado.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessarCalculoCreditoDireto()
        {
            CreditoDireto creditoDireto = new CreditoDireto(new Credito<CreditoDireto>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoDireto.Taxa });

            CreditoVO creditoVODireto = creditoDireto.Calcular();

            Console.Clear();

            Console.WriteLine($"Status do Crédito: {creditoVODireto.Status}\n Valor Total Com Juros: R$ {creditoVODireto.ValorTotalComJuros.ToString("#.##")} \nValor do Juros: R$ {creditoVODireto.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }

        private static void ExibirMensagemExcecaoOpcaoMenu()
        {
            Console.WriteLine("Opção inválida!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        private static void ExibirMenuPrincipal()
        {
            Console.WriteLine("Sistema de Processamento de Liberação de Crédito");

            Console.WriteLine("Digite a Opção de 1 a 5 Para Selecionar o Tipo de Crédito Desejado:");

            Console.WriteLine("1 - Crédito Direto");

            Console.WriteLine("2 - Crédito Consignado");

            Console.WriteLine("3 - Crédito Pessoa Jurídica");

            Console.WriteLine("4 - Crédito Pessoa Física");

            Console.WriteLine("5 - Crédito Imobiliário");
        }
    }
}
