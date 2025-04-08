using CustomerBalance.API.Endpoints;
using CustomerBalance.Shared.Data.Data;
using CustomerBalance.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerLedgerContext>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:CustomerLedgerDB"])
            .UseLazyLoadingProxies();
});

builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<DAL<CustomerLedger>>();

var app = builder.Build();

app.AddEndPointsCustomerLedger();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();