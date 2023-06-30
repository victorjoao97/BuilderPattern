# Repositório em C# para aplicar conceitos do Builder (Design Pattern)
[![.NET](https://github.com/victorjoao97/BuilderPattern/actions/workflows/dotnet.yml/badge.svg)](https://github.com/victorjoao97/BuilderPattern/actions/workflows/dotnet.yml)  

_Os requisitos para executar esse projeto é ter um ambiente .NET 7 ou utilizar o Docker_

Para executar os testes execute o comando:
```
dotnet test
```

Para executar o console execute o comando:
```
dotnet run --project .\ConsoleClient\ConsoleClient.csproj
```

Se quiser utilizar docker, siga os passos abaixo para executar o projeto sem precisar instalar o dotnet:
```
docker build -t dotnet-builderpattern .
docker run -it dotnet-builderpattern
```

O problema encontrado era utilizar uma classe que possui parâmetros no construtor que são opcionais para determinados métodos, pois quando era necessário criar testes ou utilizar a classe no Cliente, havia o trabalho que omitir parâmetros no construtor.  
Para esse problema foi utilizado o padrão Builder por ser um padrão de projeto criacional, facilita a criação de objetos complexos permitindo que eles sejam criados passo a passo, reutiliza código e centraliza o local onde os objetos são criados.

Dessa forma criei uma `interface` comum com os passos que é necessário para criar o objeto final. Depois implementei duas classes concretas, uma que irá gerar o objeto para ser utilizado no Cliente e outra para gerar o objeto nos Testes Unitários.  
Após criei um Diretor que sabe dos passos onde existe dois métodos que constrói um objeto para "salvar um produto" e constrói um objeto para "buscar a data atual".  

Assim, os Testes Unitários compartilham do mesmo Diretor, a única diferença é no Builder que é passado para ele. Pois nos Testes ele utiliza o Builder que permite criar `mocks`, e no Builder de Produção que utiliza as classes concretas.

Dessa forma, abstrai a criação desse objeto complexo, permitindo que eu o crie de forma diferente em outros cenários.

As referências para esse projeto vieram principalmente do site [Refactoring Guru](https://refactoring.guru/design-patterns/builder), onde existe ótimas explicações sobre como e quando aplicar esse padrão.
