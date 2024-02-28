SELECT emp.guid, emp.first_name, emp.last_name
FROM tb_m_employees as emp
LEFT JOIN tb_tr_bookings as book ON emp.guid = book.employee_guid
WHERE book.employee_guid  is NULL;

select * from tb_tr_bookings