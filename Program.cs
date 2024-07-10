using System;

namespace DatesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Configuração de culturas para formatação de datas
            var pt = new System.Globalization.CultureInfo("pt-BR");
            var de = new System.Globalization.CultureInfo("de-DE");
            var atual = System.Globalization.CultureInfo.CurrentCulture;

            // Exibe a data e hora atual formatada de acordo com a cultura atual
            Console.WriteLine(DateTime.Now.ToString("D", atual));
            Console.WriteLine(DateTime.Now.ToString("d", atual));

            // Exibe a data e hora atual formatada de acordo com a cultura brasileira (pt-BR)
            Console.WriteLine(DateTime.Now.ToString("D", pt));
            Console.WriteLine(DateTime.Now.ToString("d", pt));

            // Exibe a data e hora atual formatada de acordo com a cultura alemã (de-DE)
            Console.WriteLine(DateTime.Now.ToString("D", de));
            Console.WriteLine(DateTime.Now.ToString("d", de));

            // Exemplos de manipulação de fuso horário
            var dateTime = DateTime.UtcNow; // Obtém a data e hora atual em UTC
            Console.WriteLine(dateTime);
            Console.WriteLine(dateTime.ToLocalTime()); // Converte para a hora local

            Console.WriteLine("======================");


            // Encontra o fuso horário da região de Auckland, Nova Zelândia
            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            Console.Write(timezoneAustralia);

            // Converte a data e hora atual em UTC para o fuso horário de Auckland
            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(dateTime, timezoneAustralia);
            Console.WriteLine(horaAustralia);

            // Converte a hora de Auckland de volta para UTC
            var horaAtual = TimeZoneInfo.ConvertTimeToUtc(horaAustralia, timezoneAustralia);
            Console.WriteLine(horaAtual);

            // Listagem de todos os fusos horários disponíveis no sistema
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones)
            {
                Console.WriteLine(timezone.Id); // Exibe o ID do fuso horário
                Console.WriteLine(timezone); // Exibe informações detalhadas do fuso horário
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dateTime, timezone)); // Converte a hora UTC para o fuso horário atual
                Console.WriteLine("======================");
            }

            // Encontra o fuso horário do Brasil
            var brazilTime = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Exemplos de criação de TimeSpan
            var timeSpan = new TimeSpan(); // TimeSpan padrão (0)
            Console.WriteLine(timeSpan);

            var timeSpanNanosegundos = new TimeSpan(1); // TimeSpan com 1 tick (100 nanossegundos)
            Console.WriteLine(timeSpanNanosegundos);

            var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8); // TimeSpan de 5 horas, 12 minutos e 8 segundos
            Console.WriteLine(timeSpanHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10); // TimeSpan de 3 dias, 5 horas, 50 minutos e 10 segundos
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundoMilissegundo = new TimeSpan(15, 12, 55, 8, 100); // TimeSpan com 15 dias, 12 horas, 55 minutos, 8 segundos e 100 milissegundos
            Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo);

            // Operações com TimeSpan
            Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo); // Exemplo de subtração de TimeSpans
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days); // Obtém o número de dias do TimeSpan
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0))); // Adiciona um intervalo de tempo ao TimeSpan

            // Exemplos de manipulação de datas
            Console.WriteLine(DateTime.DaysInMonth(2020, 2)); // Obtém o número de dias no mês de fevereiro de 2020
            Console.WriteLine(IsWeekend(DateTime.Now.DayOfWeek)); // Verifica se o dia de hoje é fim de semana
            Console.WriteLine(DateTime.Now.IsDaylightSavingTime()); // Verifica se está no horário de verão
        }

        static bool IsWeekend(DayOfWeek today)
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}