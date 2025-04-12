# Используемые библиотеки

## API
```
Swashbukle
Microsoft.IdentityModel.Tokens
Microsoft.Owin.Security.Jwt
```

## Desktop
```
LiveCharts.Wpf
Newtonsoft.Json
```

## Web
```
Aspose.Words
DocumentFormat.OpenXml
DocX
itext7
itext.bouncy-castle-adapter

Blazorise
Blazorise.Bootstrap
Blazorise.Components
Blazorise.DataGrid
Blazorise.Icons.FontAwesome
Blazorise.PdfViewer


Selenium.Support
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
```

# Подготоовка Проектов

## Api

### Swashbuckle
C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\Microsoft\Web\Mvc\Scaffolding\Templates\ApiControllerWithContext
```
// GET: <#= routePrefix #>
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все <#= ModelTypeName #>")]
        public IQueryable<<#= ModelTypeName #>> Get<#= entitySetName #>()
        {
            return db.<#= entitySetName #>;
        }
```

### JWT token

Startup
```
public void Configuration(IAppBuilder app)
{
    var secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];
    var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
    var audience = ConfigurationManager.AppSettings["JwtAudience"];

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

    app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
    {
        AuthenticationMode = AuthenticationMode.Active,
        TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = key,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true
        }
    });
}
```

authcontroller
```
private string GenerateJwtToken(string username)
{
    var secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];
    var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
    var audience = ConfigurationManager.AppSettings["JwtAudience"];

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, username),
    };

    var token = new JwtSecurityToken(
        issuer,
        audience,
        claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}
```

### Cryptography
**ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);**

```
public static byte[] Protect(byte[] data)
{
    try
    {
        // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
        // only by the same current user.
        return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
    }
    catch (CryptographicException e)
    {
        Console.WriteLine("Data was not encrypted. An error occurred.");
        Console.WriteLine(e.ToString());
        return null;
    }
}

```

## Desktop 

### LiveCharts

#### Pie
```
<lvc:PieChart x:Name="PStae" InnerRadius="1"
                              Grid.Row="1">
```
#### ColumnSeries
```
 <lvc:CartesianChart Name="LVSales" Grid.Row="1">
                    <lvc:CartesianChart.AxisX>
                        <lvc:Axis Labels="{Binding LabelSales}" Separator="{Binding Separator}"/>
                    </lvc:CartesianChart.AxisX>
</lvc:CartesianChart>
```

#### AngularGauge
```
<lvc:AngularGauge Grid.Row="1"  Value="{Binding ValueEffects}" LabelsStep="100" SectionsInnerRadius="0.5">
                    <lvc:AngularGauge.Sections>
                        <lvc:AngularSection FromValue="1" ToValue="100" Fill="#00cc33"/>
                    </lvc:AngularGauge.Sections>
</lvc:AngularGauge>
```


## Web

### Blazorise

App.razor
```
 <link href="_content/Blazorise/blazorise?v=1.7.5.0" rel="stylesheet"/>
   <link href="_content/Blazorise.Bootstrap/blazorise.bootstrap?v=1.7.5.0" rel="stylesheet"/>
```

Program.cs
```
builder.Services.AddBlazorise((opt)=>opt.Immediate = true)
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
```

#### ModalProvider
```

[Inject] IModalService modalService { get; set; }
private Task ShowModal()
	{
		var options = new ModalInstanceOptions
			{
				Size = ModalSize.ExtraLarge
			};
		return modalService.Show<SelectMachin>(Localizer["SelectMachin"], options);
	}
```

#### DataGrid

```
<DataGrid TItem="VendingMachin"
		  Data="@vendingMachins"
		  ShowPager
		  ShowPageSizes
		  PagerPosition="DataGridPagerPosition.Top">
	<DataGridColumns>
		<DataGridCommandColumn />
		<DataGridColumn Field="@nameof(VendingMachin.Id)" Caption="#"/>
		<DataGridColumn Field="@nameof(VendingMachin.Name)" Caption="Name"  />
		<DataGridColumn TItem="VendingMachin" Caption="Model">
			<DisplayTemplate>
				@(context.Model.Name)
			</DisplayTemplate>
		</DataGridColumn>
		<DataGridColumn Field="@nameof(VendingMachin.FullAdress)" Caption="Adress"  />
		<DataGridColumn Field="@nameof(VendingMachin.InitWork)" Caption="Init date"  />
		<DataGridColumn TItem="VendingMachin" Caption="Action">
			<DisplayTemplate>
				<div class="action">
					✏🧺🔓
				</div>
			</DisplayTemplate>
		</DataGridColumn>
	</DataGridColumns>

	<NextPageButtonTemplate>
		<Text>➡</Text>
	</NextPageButtonTemplate>
	<PreviousPageButtonTemplate>
		<Text>⬅</Text>
	</PreviousPageButtonTemplate>
</DataGrid>
```

#### PdfViewer

```
<Blazorise.PdfViewer.PdfViewerContainer>
		<Button Clicked="@(()=>pdfViewr.PreviousPage())">⬅</Button>
		<Button Clicked="@(()=>pdfViewr.NextPage())">➡</Button>
		<Blazorise.PdfViewer.PdfViewer @ref="pdfViewr" Source='@($"data:application/pdf;base64,{Convert.ToBase64String(contextReport.ReportData)}")'></Blazorise.PdfViewer.PdfViewer>
	</Blazorise.PdfViewer.PdfViewerContainer>
@code {
	PdfViewer pdfViewr;
}
```

### Aspose Docx Documnet.OpenXML

```
           var fileTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ReportTemplate.docx");

            using (var wordFile = new MemoryStream())
            {
                using (var wordDocument = DocX.Load(fileTemplate))
                {
                    wordDocument.ReplaceText("{", "");
                    wordDocument.SaveAs(wordFile);
                }

                wordFile.Seek(0, SeekOrigin.Begin);

                var wordAspose = new Aspose.Words.Document(wordFile);

                using (var pdf = new MemoryStream())
                {
                    wordAspose.Save(pdf, SaveFormat.Pdf);
                    return pdf.ToArray();
                }
            }
```

### itext7 itext.bouncy-castle-adapter

```
 public static byte[] InsertSign(byte[] file, byte[] sign)
        {
            using (var oldFile = new MemoryStream(file))
            using (var newFile = new MemoryStream())
            using (var pdfReader = new PdfReader(oldFile))
            using (var pdfWriter = new PdfWriter(newFile))
            using (var pdfDocument = new PdfDocument(pdfReader, pdfWriter))
            {
                var document = new Document(pdfDocument);
                
                var image = new iText.Layout.Element.Image(ImageDataFactory.Create(sign));

                image.ScaleToFit(100, 100);
                image.SetFixedPosition(pdfDocument.GetNumberOfPages(), 50, 50);
                
                document.Add(image);
                document.Close();
                return newFile.ToArray();
            } 
        }
    }
```



## Тестирование

### Selenium
```
Selenium.Support
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
```


