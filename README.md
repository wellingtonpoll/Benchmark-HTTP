# BENCHMARK
## .NET HTTP benchmark

O projeto é constituído por duas aplicações, uma API que é responsável por receber as requisições e uma aplicação console onde o banchmark foi implementado utilizando a biblioteca [BenchmarkDotNet](https://www.nuget.org/packages/BenchmarkDotNet/). A implementação consiste em realizar uma requisição HTTP para a API do próprio repositório utilizando as seguintes bibliotecas:

- System.Net.Http [580.8M downloads nuget.org]
- RestSharp: 98.6M downloads nuget.org , Github: 8.1k Stars, Github: 2.2k Forks, Github: 220 Contributors
- Flurl.Http: 15.5M downloads nuget.org, Github: 2.8k Stars, Github: 273k Forks, Github: 24 Contributors

## Métricas
A biblioteca BenchmarkDotNet captura as métricas de cada requisição HTTP em uma série de execuções gerando um relatório com as seguintes colunas:

- [Mean] - Média aritmética de todas as medidas
- [Error] - Metade do intervalo de confiança de 99,9%
- [StdDev] - Desvio padrão de todas as medições
- [StdErr] - Erro padrão de todas as medições
- [Min] - Mínimo
- [Q1] - 25% da execução
- [Median] - Valor que separa a metade superior de todas as medições (50%)
- [Q3] - 75% da execução
- [Max] - Máximo
- [Op/s] - Operação por segundo
- [Rank] - Posição relativa da média de referência atual entre todas as referências
- [Gen 0] - GC geração 0, colétas a cada 1000 operações
- [Gen 1] - GC geração 1, colétas a cada 1000 operações
- [Allocated] - Memória alocada por operação única

## Execução
Primeiro restaure os pacotes executando o seguinte comando no diretório do arquivo "Benchmark.Http.Sample.sln"
```sh
dotnet restore "Benchmark.Http.Sample.sln"
```
Execute o projeto Benchmark.Http.Sample.Api com o seguinte comando no diretório do arquivo "Benchmark.Http.Sample.Api.csproj"
```sh
dotnet run -c release "Benchmark.Http.Sample.Api.csproj"
```
Agora execute o projeto Benchmark.Http.Sample.ConsoleApp com o seguinte comando no diretório do arquivo "Benchmark.Http.Sample.ConsoleApp.csproj"
```sh
dotnet run -c release "Benchmark.Http.Sample.ConsoleApp.csproj"
```
Agora é só aguardar o término da execução, ao finalizar no console você verá algo semelhante a tabela abaixo.
![Console](https://github.com/wellingtonpoll/Benchmark-HTTP/blob/main/assets/banchmark_console_summary.png)

Esses resultados nos mostram que a biblioteca Flurl se mostrou muito mais eficiente, sendo mais rápida, consumindo menos memória, sendo melhor gerenciada pelo GC e o mais importante, um número de operações/segundo bem superior se compararmos com o HTTP Client do System.Net.Http e com o RestSharp. 
A execução do banchmark também gera o diretório "__banchmark-http/src/Benchmark.Http.Sample.ConsoleApp/BenchmarkDotNet.Artifacts__" contendo arquivos com os mesmos resultados.

## License

MIT