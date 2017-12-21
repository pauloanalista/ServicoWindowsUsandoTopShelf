# ServicoWindowsUsandoTopShelf
Exemplo de serviço windows sendo construído com o pacote nuget topshelf

## Como criar um Serviço Windows
1- Criar uma aplicação do tipo Console Application

2 - Instalar pacote Nuget chamado TopShelf

3 - Criar uma classe que será seu serviço

```csharp
namespace WindowsServiceWithTopshelf  
{  
    public class MyService  
    {  
        public void Start()  
        {  
            // write code here that runs when the Windows Service starts up.  
        }  
        public void Stop()  
        {  
            // write code here that runs when the Windows Service stops.  
        }  
    }  
}  
```

4 - Criar uma classe para configurar o TopShelf
using Topshelf;  

```csharp
namespace WindowsServiceWithTopshelf  
{  
    internal static class ConfigureService  
    {  
        internal static void Configure()  
        {  
            HostFactory.Run(configure =>  
            {  
                configure.Service < MyService > (service =>  
                {  
                    service.ConstructUsing(s => new MyService());  
                    service.WhenStarted(s => s.Start());  
                    service.WhenStopped(s => s.Stop());  
                });  
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();  
                configure.SetServiceName("MyWindowServiceWithTopshelf");  
                configure.SetDisplayName("MyWindowServiceWithTopshelf");  
                configure.SetDescription("My .Net windows service with Topshelf");  
            });  
        }  
    }  
}  
```

5 - Abrir a classe Program do Console Application e chamar a configuração do serviço

```csharp
namespace WindowsServiceWithTopshelf  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            ConfigureService.Configure();  
        }  
    }  
}  

```
6 - Rode a aplicação como administrador

## Instalando o serviço windows
Para instalar chame o executável seguido de install
ex:

```sh
WindowsServiceWithTopshelf.exe install
```

## Desinstalando o serviço windows
Para desinstalar chame o executável seguido de uninstall
ex:
```sh
WindowsServiceWithTopshelf.exe uninstall
``` 


## Exemplo
Os arquivos deste repositório comtempla um serviço criado com TopShelf já com a configuração necessária para usar injeção de dependencia com SimpleInjector
