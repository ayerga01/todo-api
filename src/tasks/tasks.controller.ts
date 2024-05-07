import { AppDataSource } from "../.."
import { Task } from "./tasks.entity"
import { instanceToPlain } from "class-transformer"
import { Request, Response } from "express"

class TasksController {
    public async getAll(req: Request, res: Response): Promise<Response> {
        // Declara a variable to hold all tasks
        let allTasks: Task[]
        try {
            // Fetch all tasks using the reporitory
            allTasks = await AppDataSource.getRepository(Task).find() // { order: { date: 'ASC', }, } inside find?
            // Convert the tasks instance to an array of objects
            allTasks = instanceToPlain(allTasks) as Task[]
            return res.json(allTasks).status(200)
        } catch (_errors) {
            return res.json({ error: "Internal Server Error" }).status(500)
        }
    }
}

export const tasksController = new TasksController() // exporting the instance of the task
