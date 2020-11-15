# placeholder-api

[![Deploy](https://www.herokucdn.com/deploy/button.svg)](https://heroku.com/deploy)

High performance image placeholder generator API with caching support

```
GET /placeholder?options
```

### Options:
- height: `Integer` => `100` (default)
- width: `Integer` => `100` (default)
- color: `KnownColor` (enum) => `LightGrey` (default)
- text: `String` => `""` (default)
- format: `KnownImageFormat` (enum) => `Png` (default)

Enums:
- [`KnownColor`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.knowncolor?view=net-5.0#fields) source
- [`KnownImageFormat`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.imageformat?view=dotnet-plat-ext-5.0#properties) source
