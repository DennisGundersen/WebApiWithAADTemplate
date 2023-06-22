﻿CREATE TABLE [dbo.pragmatic].[Variables]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[TradingLotSize] DECIMAL(18, 2) NOT NULL,
	[ExtremeTopRate] DECIMAL(18, 4) NOT NULL,
	[NormalTopRate] DECIMAL(18, 4) NOT NULL,
	[CenterRate] DECIMAL(18, 4) NOT NULL,
	[NormalBottomRate] DECIMAL(18, 4) NOT NULL,
	[ExtremeBottomRate] DECIMAL(18, 4) NOT NULL,
	[MaxPlacementDistance] INT NOT NULL,
	[TestUpToRate] DECIMAL(18, 4) NOT NULL,
	[TestDownToRate] DECIMAL(18, 4) NOT NULL,
	[TestPipsUp] INT NOT NULL,
	[TestPipsDown] INT NOT NULL,
	[BalancerMinPlacementDistanceLongs] INT NOT NULL,
	[BalancerMinPlacementDistanceShorts] INT NOT NULL,
	[LongStabilizerSizeFactor] INT NOT NULL,
	[ShortStabilizerSizeFactor] INT NOT NULL,
	[LongBalancerSizeFactor] INT NOT NULL,
	[ShortBalancerSizeFactor] INT NOT NULL,
	[PrimerSizeFactor] INT NOT NULL,
	[BalancerStopLossPips] INT NOT NULL,
	[SecurePips] INT NOT NULL,
	[AutoLotIncrease] BIT NOT NULL,
	[AutoLotSafeEQLevel] INT NOT NULL,
	[TakeProfit] INT NOT NULL,
	[TradeMidTerm] BIT NOT NULL,
	[FixedSpread] INT NOT NULL,
	[ExtraLongBuffer] INT NOT NULL,
	[ExtraShortBuffer] INT NOT NULL,
	[WarningLevel] INT NOT NULL,
	[HeartbeatMonitorTimer] INT NOT NULL,
	[DatabaseLogTimer] INT NOT NULL,
	[AutoCloseExtremes] INT NOT NULL,
	[RunBalancers] INT NOT NULL,
	[RunStabilizers] INT NOT NULL,
	[RunBreakouts] INT NOT NULL,
	[RunWhiplash] INT NOT NULL,
	[RunPrimers] INT NOT NULL,
	[GMTOffset] INT NOT NULL,
	[UsePoint] DECIMAL(18, 4) NOT NULL,
	[RateDecimalNumbersToShow] INT NOT NULL,
	[IsAccountMaster] BIT NOT NULL,
	[IsSymbolMaster] BIT NOT NULL,
	[ScreenshotTimer] INT NOT NULL,
	[MaxWeight] INT NOT NULL,
	[LastUpdated] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Variables_Account] FOREIGN KEY ([Id]) REFERENCES [dbo.pragmatic].[Accounts]([Id])
)
