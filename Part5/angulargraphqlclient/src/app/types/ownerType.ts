import { AccountType } from './accountType';

export type OwnerType = {
    'id': string;
    'name': string;
    'address': string;
    'accounts': AccountType[];
}