import { Entity, PrimaryGeneratedColumn } from "typeorm";
// import { Priority } from "../enums/Priority";
// import { Status } from "../enums/Status";

@Entity() // decorator 
export class Task {

    @PrimaryGeneratedColumn("uuid")
    id: string;
}