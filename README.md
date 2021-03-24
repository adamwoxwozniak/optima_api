# Comarch Optima "API"
Projekt udostępniający bazę danych Comarch Optima dla technologii, które nie mogą połączyć się bezpośrednio do MS SQL Server.

Pobieranie danych odbywa się za pomocą body. Przykłady:

**DOKUMENTY** - wybrane kolumny, warunki (302 = faktura sprzedaży, nie korekty)
```json
{
    "columns": "TrN_TrNId,TrN_NumerPelny",
    "table": "TraNag",
    "where": "TrN_TypDokumentu = 302 and TrN_Korekta = 0",
    "sort": "TrN_TrNId desc"
}
```

**DOKUMENTY** - wszystkie kolumny, ostatnie 10 wierszy, warunki
```json
{
    "columns": "top(10) *",
    "table": "TraNag",
    "where": "TrN_TypDokumentu = 302 and TrN_Korekta = 0",
    "sort": "TrN_TrNId desc"
}
```
**KONTRAHENCI** - wszystko, tylko kod kontrahenta
```json
{
    "columns": "Knt_Kod",
    "table": "Kontrahenci",
    "where": "",
    "sort": ""
}
```
