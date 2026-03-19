CREATE TABLE calculation_history (
    id INT AUTO_INCREMENT PRIMARY KEY,
    operand1 INT NOT NULL,
    operand2 INT NOT NULL,
    operation VARCHAR(50) NOT NULL,
    calculator_type VARCHAR(50) NOT NULL,
    result INT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);