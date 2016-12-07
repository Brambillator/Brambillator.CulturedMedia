# Brambillator.CulturedMedia
Provides a domain for internationalized media, whether it's string or path to files.


Usage example:
```cs
service.AddTextResource("en-US", "MYTH", "Myth", "a traditional or legendary story, usually concerning some being or hero or event, with or without a determinable basis of fact or a natural explanation, especially one that is concerned with deities or demigods and explains some practice, rite, or phenomenon of nature.");
service.AddTextResource("en-US", "MYTH", "Mito", "Lenda; narrativa de teor fantástico, simbólico, normalmente com personagens ou seres que incorporam as forças da natureza e as características humanas.");
```

```cs
Resource resMyth = service.GetResource(CultureInfo.CurrentUICulture.Name, "MYTH");
```
