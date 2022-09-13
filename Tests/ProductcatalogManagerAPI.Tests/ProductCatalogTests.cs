namespace ProductcatalogManagerAPI.Tests
{
    public class ProductCatalogTests
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _application;

        [SetUp]
        public void Setup()
        {
            _application = new WebApplicationFactory<Program>();
            _httpClient = _application.CreateClient(new() { BaseAddress = new System.Uri("https://localhost:44383/api/ProductCatalog/") });
        }

        [Test]
        public async Task Tests()
        {
            //Assert Add
            var entity = new ProductDto()
            {
                Code = Guid.NewGuid().ToString("N").ToUpper()[..10],
                Name = $"Unit Test {Guid.NewGuid().ToString()[..10]}",
                Picture = "https://picsum.photos/200/300",
                Price = Convert.ToDecimal(12.45)
            };
            var content = new StringContent(Serializer.JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var add = await _httpClient.PostAsync($"Add", content);
            var addResponse = JsonSerializer.Deserialize<bool>(await add.Content.ReadAsStreamAsync());
            Assert.That(addResponse, Is.True);

            //Assert List
            var list = await _httpClient.GetFromJsonAsync<List<ProductDto>>("List");
            Assert.That(list, Is.Not.Null);

            //Assert Get
            var item = list.FirstOrDefault();
            var getItem = await _httpClient.GetFromJsonAsync<ProductDto>($"Get/{item?.Id}");
            Assert.That(getItem, Is.Not.Null);

            //Assert Update
            getItem.Name = "Unit Test " + Guid.NewGuid().ToString().Substring(0, 10);
            content = new StringContent(Serializer.JsonConvert.SerializeObject(getItem), Encoding.UTF8, "application/json");
            var update = await _httpClient.PostAsync($"Update", content);
            Assert.That(JsonSerializer.Deserialize<bool>(await update.Content.ReadAsStreamAsync()), Is.True);

            //Assert Search
            var search = await _httpClient.GetFromJsonAsync<List<ProductDto>>($"Search/{getItem.Name}");
            Assert.That(search, Is.Not.Null);

            //Assert Remove
            var remove = await _httpClient.GetFromJsonAsync<bool>($"Remove/{getItem.Id}");
            Assert.That(remove, Is.True);
        }
    }
}