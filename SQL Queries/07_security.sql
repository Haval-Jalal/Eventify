CREATE ROLE EventifyReader;
GO

CREATE USER eventify_user WITHOUT LOGIN;
GO

ALTER ROLE EventifyReader ADD MEMBER eventify_user;
GO

GRANT SELECT ON vw_PublicCustomers TO EventifyReader;
GRANT SELECT ON vw_OrderReport TO EventifyReader;
GO

-- Testa rollen genom SELECTs nedan

--EXECUTE AS USER = 'eventify_user';

--SELECT * FROM vw_PublicCustomers;   -- Ska fungera
--SELECT * FROM vw_OrderReport;       -- Ska fungera

--SELECT * FROM Customers;            -- Ska FAILA