## Order By

```bash
dotnet run --project src/OrderBy/OrderBy.csproj -- --insert
dotnet run --project src/OrderBy/OrderBy.csproj -- --order
```

## Query

``bash
wk-send-command --database OrderBy --sql 'show lc_collate'
wk-send-command --database OrderBy --sql 'show lc_ctype'
wk-send-command --database OrderBy --sql "select * from pg_collation where \"collname\" LIKE '%t%'"

wk-send-command --database OrderBy --sql 'SELECT "ThaiText" FROM "Students" ORDER BY "ThaiText"'
wk-send-command --database OrderBy --sql 'SELECT "ThaiText" FROM "Students" ORDER BY "ThaiText" COLLATE "C"'
wk-send-command --database OrderBy --sql 'SELECT "ThaiText" FROM "Students" ORDER BY "ThaiText" COLLATE "th-TH-x-icu"'
```