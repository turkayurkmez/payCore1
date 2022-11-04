using eshop.Messages;
using MassTransit;
using MediatR;
using Orders.API.Consumers;
using Orders.API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMassTransit(config =>
{
    config.AddTotalConsumers();


    config.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });
        configurator.ReceiveEndpoint(nameof(ProductPriceChanged), e => e.ConfigureConsumer<ProductPriceChangedEventConsumer>(context));
        configurator.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
