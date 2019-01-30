import { PersonWithIdAbstractBase } from 'src/app/shared/personwithid-abstract-base.model';
import { Dependent } from '../dependents/shared/dependent.model';
import { YearlyPaymentSummary } from './yearly-payment-summary.model';

export class Employee extends PersonWithIdAbstractBase {
    yearlyPayment: number;
    dependents: Dependent[];
    yearlyPaymentSummary: YearlyPaymentSummary;
}
