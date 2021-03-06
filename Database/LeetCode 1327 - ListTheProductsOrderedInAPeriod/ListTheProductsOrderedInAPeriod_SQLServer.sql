WITH bigOrder AS (SELECT product_id, SUM(unit) AS unit FROM orders WHERE LEFT(order_date, 7) = '2020-02' GROUP BY product_id, LEFT(order_date, 7) HAVING SUM(unit) >= 100)
SELECT p.product_name, b.unit FROM bigOrder b LEFT JOIN products p ON b.product_id = p.product_id