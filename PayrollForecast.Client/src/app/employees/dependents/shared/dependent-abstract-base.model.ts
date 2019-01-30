import { PersonWithIdAbstractBase } from 'src/app/shared/personwithid-abstract-base.model';

export abstract class DependentAbstractBase extends PersonWithIdAbstractBase {
    employeeId: number;
}
