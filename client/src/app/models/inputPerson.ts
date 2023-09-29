import { Gender } from "./gender";
import { InputContact } from "./inputContact";

export interface InputPerson extends InputContact {
    birthDate?: Date;
    gender?: Gender;
}
