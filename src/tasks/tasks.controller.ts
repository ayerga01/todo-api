import { AppDataSource } from "../..";
import { Task } from "./tasks.entity";
import { instanceToPlain } from "class-transformer";

export class TasksController {

    constructor(private tasksRepository = AppDataSource.getRepository(
        Task,
    )) {}

    // @ts-ignore
    public async getAll(): Promise<Task[]> {
        // Declara a variable to hold all tasks
        let allTasks: Task[];

        // Fetch all tasks using the reporitory
        try
        {
            allTasks = await this.tasksRepository.find(); // { order: { date: 'ASC', }, } inside find?

            // Convert the tasks instance to an array of objects
            allTasks = instanceToPlain(allTasks) as Task[];

            return allTasks;
        }
        catch(errors)
        {
            console.log(errors)
        }
    }
}