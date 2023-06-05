# ZeroMQ - Sistemas Distribuídos.

##### Resultados obtidos no terminal
![terminal](https://github.com/mateusxfl/zero-mq-example/assets/78103632/7aeaf1df-9db6-45c6-91f5-98691758f786)

OBS: Para realizar os testes, tenha previamente instalado o **.NET 6.0** na sua máquina.

---

> Primeiramente, clone o projeto.
``````
git clone https://github.com/mateusxfl/zero-mq-example.git
``````
> Abra dois teminais e localize a pasta do mesmo em ambos.

![localizando](https://github.com/mateusxfl/zero-mq-example/assets/78103632/3f8985a0-444a-4abc-b107-769302e6fbe1)

> Em um execute o comando abaixo para startar o projeto com o código dos Subscribers:
``````
dotnet run --project ./Subscriber/Subscriber.csproj
``````
> Em outro execute o comando abaixo para startar o projeto com o código dos Publishers:
``````
dotnet run --project ./Publisher/Publisher.csproj
``````
