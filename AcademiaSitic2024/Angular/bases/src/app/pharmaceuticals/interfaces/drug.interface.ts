import { EPharmaType } from "./enums.interface";

export interface Drug {
    name: string;
    price: number;
    type: EPharmaType
}