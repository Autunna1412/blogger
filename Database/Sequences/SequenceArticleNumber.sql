IF NOT EXISTS
(
	SELECT [name]
	FROM sys.sequences
	WHERE [name] = 'SequenceArticleNumber'
)
BEGIN
	CREATE SEQUENCE [DBO].SequenceArticleNumber AS INT
	START WITH 1
	INCREMENT BY 1
END

GO
