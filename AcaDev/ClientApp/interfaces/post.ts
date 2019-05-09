
export interface IPost {
    id: number;
    title: string;
    content: string;
    author: string;
    date: Date;
    tags: string[];
}

export interface IComment {
    id: number;
    author: string;
    content: string;
    date: Date;
}