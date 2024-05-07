import { validationResult } from "express-validator"
import { AppDataSource } from "../.."
import { Task } from "./tasks.entity"
import { instanceToPlain } from "class-transformer"
import { Request, Response } from "express"

class TasksController {
    // Method for the get route
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

    // Method for the post route
    public async create(req: Request, res: Response): Promise<Response> {
        const errors = validationResult(req)

        if (!errors.isEmpty()) {
            return res.status(400).json({ errors: errors.array() })
        }

        // Create a new instance of a task
        const newTask = new Task()

        // Add the required properties to the Task object
        newTask.title = req.body.title
        newTask.date = req.body.date
        newTask.description = req.body.description
        newTask.priority = req.body.priority
        newTask.status = req.body.status

        // Add the new task to the database
        let createdTask: Task

        try {
            createdTask = await AppDataSource.getRepository(Task).save(newTask)

            // Convert instance to a plain object
            createdTask = instanceToPlain(createdTask) as Task

            return res.json(createdTask).status(200)
        } catch (_errors) {
            return res.json({ error: "Internal Server Error" }).status(500)
        }
    }
}

export const tasksController = new TasksController() // exporting the instance of the task
