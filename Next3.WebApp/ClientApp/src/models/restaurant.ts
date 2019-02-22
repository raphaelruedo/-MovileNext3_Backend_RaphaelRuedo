import { Entity } from './entity';

export class Restaurant extends Entity {
    id: string;
    name: string;
    description: number;
    isActive: number;

    constructor(args) {
        super(args)
    }
}