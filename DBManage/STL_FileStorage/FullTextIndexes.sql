CREATE FULLTEXT INDEX ON [dbo].[p_FileShareTable]
    ([file_stream] TYPE COLUMN [file_type] LANGUAGE 1049, [name] LANGUAGE 1049)
    KEY INDEX [PK_FileShare]
    ON [FileShareCatalog];

