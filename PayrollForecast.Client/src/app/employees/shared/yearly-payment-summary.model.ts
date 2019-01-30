import { Deduction } from './deduction.model';

export class YearlyPaymentSummary {
    initialValue: number;
    deductions: Deduction[];
    total: number;
}
