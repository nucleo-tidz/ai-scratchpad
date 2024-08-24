using ai.scratchpad.UseCases.Summarise;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using System.Reflection;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {

        //    Kernel kernel = Kernel.CreateBuilder()
        //.AddOpenAIChatCompletion(model, key)
        //.Build();

        services.AddTransient<Kernel>(serviceProvider =>
        {
            var kernelBuilder = Kernel.CreateBuilder();
            kernelBuilder.Services.AddOpenAIChatCompletion("gpt-3.5-turbo", "");
            var kernel = kernelBuilder.Build();
            return kernel;
        });
        services.AddOpenAIChatCompletion("gpt-3.5-turbo", "");
        services.AddTransient<ISummary, Summary>();
    })
    .Build();

var my = host.Services.GetRequiredService<ISummary>();
await my.Summarise($"""
    I am a Lead Engineer with over 13 years of experience in software development and system architecture, with a strong focus on .NET Core. Throughout my career, I have played a pivotal role in designing, developing, and maintaining complex applications across diverse industries. My expertise in Azure Platform-as-a-Service (PaaS) is extensive, encompassing services like Azure App Services, Azure Functions, Azure SQL Database, Azure Data Factory, Azure Storage Account , Traffic manager , Logic App etc. I also excel in containerization with Docker and in orchestrating large-scale deployments using Kubernetes.
    
    I am well-known for my proficiency in event-driven design, having built robust and scalable systems using Apache Kafka. My expertise in Command Query Responsibility Segregation (CQRS) allows me to design efficient data processing architectures and simplified system structures. My background in high-availability architecture ensures that the systems I create are resilient, reliable, and capable of handling high production loads.
    """);