SELECT first_name
FROM tb_m_employees
GROUP BY first_name
HAVING COUNT(*) > 1;

select * from tb_m_employees