SELECT 
    SUM(CASE WHEN DueDate > '2023-03-25' THEN Amount ELSE 0 END) AS TotalUndue,
    SUM(CASE WHEN DueDate <= '2023-03-25' THEN Amount ELSE 0 END) AS TotalOverdue
FROM 
    Tagihan;