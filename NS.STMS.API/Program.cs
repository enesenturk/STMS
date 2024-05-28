using NS.STMS.API.Converters.CustomJSonConverters;
using NS.STMS.API.Extentions;
using NS.STMS.API.Filters;
using NS.STMS.API.Middlewares;
using NS.STMS.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.BindMapper();
builder.Services.BindDataAccess();
builder.Services.BindBusinessRules();
builder.Services.BindManagers();

builder.Services.AddControllers().AddJsonOptions(opts =>
{
	opts.JsonSerializerOptions.PropertyNamingPolicy = null;
	opts.JsonSerializerOptions.DictionaryKeyPolicy = null;

	opts.JsonSerializerOptions.Converters.Add(new booleanJSonConverter());
	opts.JsonSerializerOptions.Converters.Add(new intJSonConverter());
	opts.JsonSerializerOptions.Converters.Add(new decimalJSonConverter());
	opts.JsonSerializerOptions.Converters.Add(new doubleJSonConverter());
	opts.JsonSerializerOptions.Converters.Add(new dateTimeJSonConverter());
});

builder.Services.AddMvc(options =>
{
	//options.Filters.Add(typeof(TrackExecution));
	options.Filters.Add(typeof(ExceptionHandler));
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("stms-cors", policy =>
	{
		policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
					.AllowAnyHeader()
					.AllowAnyMethod();
	});
});

ConnectionSettings.DbConnectionString = builder.Configuration.GetSection("DbConnectionString").Value;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ResponseBodyLengthMiddleware>();
app.UseCors("stms-cors");
app.MapControllers();
app.RegisterEntityProperties();
app.Run();