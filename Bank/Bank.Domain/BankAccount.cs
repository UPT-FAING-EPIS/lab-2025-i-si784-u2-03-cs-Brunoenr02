using System;

namespace Bank.Domain
{
    /// <summary>
    /// Representa una cuenta bancaria con operaciones de débito y crédito.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Mensaje de error cuando el monto a debitar excede el saldo.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Mensaje de error cuando el monto a debitar es menor que cero.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        /// <summary>
        /// Mensaje de error cuando el monto a acreditar es menor que cero.
        /// </summary>
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BankAccount"/>.
        /// </summary>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="balance">Saldo inicial.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Obtiene el nombre del cliente.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Obtiene el saldo de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Debita un monto de la cuenta.
        /// </summary>
        /// <param name="amount">Monto a debitar.</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount;
        }

        /// <summary>
        /// Acredita un monto en la cuenta.
        /// </summary>
        /// <param name="amount">Monto a acreditar.</param>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            m_balance += amount;
        }
    }
}
