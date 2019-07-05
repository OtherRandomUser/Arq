using System.Linq;
using Arq.Data;
using Arq.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arq.WebApi.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost Seed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
                using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();

                    var course = context.Courses.FirstOrDefault();
                    if (course == null)
                    {
                        course = new Course("GRA004124", "Ciência da Computacao");
                        context.Courses.Add(course);
                        context.SaveChanges();
                    }

                    var student = context.Students.FirstOrDefault();
                    if (student == null)
                    {
                        student = new Student("Julio", "julio", "julio", "Q1W2E3R4T5Y6U7I", course);
                        context.Students.Add(student);
                        context.SaveChanges();
                    }

                    var curriculum = context.Curriculums.FirstOrDefault();
                    if (curriculum == null)
                    {
                        curriculum = new Curriculum(course, "F", "Aquele que nao durou muito");
                        context.Curriculums.Add(curriculum);
                        context.SaveChanges();
                    }

                    if (!context.Subjects.Any())
                    {
                        // first semester
                        var lee = new Subject(curriculum, "UCS0101", "Leitura e Escrita na Formacao UniversitAria", 6, 1);
                        var et = new Subject(curriculum, "UCS0103", "etica", 6, 1);
                        var met = new Subject(curriculum, "INF00243", "Metodos de Estudo em Tecnologia", 6, 1);
                        var alg = new Subject(curriculum, "INF00244", "Algoritmos", 6, 1);
                        var sdi = new Subject(curriculum, "ELE0241", "Sistemas Digitais I", 6, 1);
                        var prc = new Subject(curriculum, "MAT0356", "Pre-CAlculo", 6, 1);
                        var md = new Subject(curriculum, "MAT0345", "MatemAtica Discreta", 6, 1);
                        context.Subjects.Add(lee);
                        context.Subjects.Add(et);
                        context.Subjects.Add(met);
                        context.Subjects.Add(alg);
                        context.Subjects.Add(sdi);
                        context.Subjects.Add(prc);
                        context.Subjects.Add(md);
                        context.SaveChanges();

                        met.CoRequirements.Add(new CoRequirement(met, alg));
                        met.CoRequirements.Add(new CoRequirement(met, sdi));
                        context.Subjects.Update(met);
                        context.SaveChanges();

                        alg.CoRequirements.Add(new CoRequirement(alg, met));
                        alg.CoRequirements.Add(new CoRequirement(alg, sdi));
                        context.Subjects.Update(met);
                        context.SaveChanges();

                        sdi.CoRequirements.Add(new CoRequirement(sdi, alg));
                        sdi.CoRequirements.Add(new CoRequirement(sdi, met));
                        context.Subjects.Update(met);
                        context.SaveChanges();

                        // second semester
                        var pe = new Subject(curriculum, "INF0245", "Programacao Estruturada", 6, 2);
                        var lc = new Subject(curriculum, "INF0202", "Logica para Computacao", 6, 2);
                        var aci = new Subject(curriculum, "SIS0560", "Arquitetura de Computadores I", 6, 2);
                        var lsd = new Subject(curriculum, "AUT0217", "Laboratorio de Sistemas Digitais",  6, 2);
                        var ga = new Subject(curriculum, "MAT0358", "Geometria Analitica", 6, 2);
                        var cc = new Subject(curriculum, "MAT0454", "CAlculo para Computacao", 6, 2);
                        var ptpe = new Subject(curriculum, "INF0246", "Projeto TemAtico: Programacao Estruturada", 6, 2);
                        context.Subjects.Add(pe);
                        context.Subjects.Add(lc);
                        context.Subjects.Add(aci);
                        context.Subjects.Add(lsd);
                        context.Subjects.Add(ga);
                        context.Subjects.Add(cc);
                        context.Subjects.Add(ptpe);
                        context.SaveChanges();

                        pe.Prerequisites.Add(new Prerequisite(pe, alg));
                        context.Subjects.Update(pe);
                        context.SaveChanges();

                        // aci.Prerequisites.Add(new Prerequisite(aci, sdi));
                        // context.Subjects.Update(aci);
                        // context.SaveChanges();

                        context.Prerequisites.Add(new Prerequisite(aci, sdi));
                        context.SaveChanges();

                        lsd.Prerequisites.Add(new Prerequisite(lsd, sdi));
                        context.Subjects.Update(aci);
                        context.SaveChanges();

                        ga.Prerequisites.Add(new Prerequisite(prc, ga));
                        context.Subjects.Update(aci);
                        context.SaveChanges();

                        cc.Prerequisites.Add(new Prerequisite(cc, ga));
                        context.Subjects.Update(aci);
                        context.SaveChanges();

                        ptpe.Prerequisites.Add(new Prerequisite(ptpe, met));
                        ptpe.CoRequirements.Add(new CoRequirement(ptpe, pe));
                        ptpe.CoRequirements.Add(new CoRequirement(ptpe, aci));
                        ptpe.CoRequirements.Add(new CoRequirement(ptpe, lsd));
                        context.Subjects.Update(aci);
                        context.SaveChanges();

                        // third semester
                        var sd = new Subject(curriculum, "INF0208", "Estrutura de Dados", 6, 3);
                        var poo = new Subject(curriculum, "INF0209", "Programacao Orientada a Objetos", 6, 3);
                        var bd = new Subject(curriculum, "INF0211", "Banco de Dados", 6, 3);
                        var tc = new Subject(curriculum, "SIS0225", "Teoria da Computacao", 6, 3);
                        var acii = new Subject(curriculum, "SIS0561", "Arquitetura de Computadores II", 6, 3);
                        var al = new Subject(curriculum, "MAT0327", "Algebra Linear", 6, 3);
                        var ptpoo = new Subject(curriculum, "INF0247", "Projeto TemAtico: Programacao Orientada a Objetos", 6, 3);
                        context.Subjects.Add(sd);
                        context.Subjects.Add(poo);
                        context.Subjects.Add(bd);
                        context.Subjects.Add(tc);
                        context.Subjects.Add(acii);
                        context.Subjects.Add(al);
                        context.Subjects.Add(ptpoo);
                        context.SaveChanges();

                        sd.Prerequisites.Add(new Prerequisite(sd, pe));
                        context.Subjects.Update(sd);
                        context.SaveChanges();

                        poo.Prerequisites.Add(new Prerequisite(poo, pe));
                        context.Subjects.Update(poo);
                        context.SaveChanges();

                        bd.Prerequisites.Add(new Prerequisite(bd, alg));
                        context.Subjects.Update(bd);
                        context.SaveChanges();

                        tc.Prerequisites.Add(new Prerequisite(tc, pe));
                        tc.Prerequisites.Add(new Prerequisite(tc, lc));
                        context.Subjects.Update(tc);
                        context.SaveChanges();

                        acii.Prerequisites.Add(new Prerequisite(acii, aci));
                        context.Subjects.Update(acii);
                        context.SaveChanges();

                        al.Prerequisites.Add(new Prerequisite(al, ga));
                        context.Subjects.Update(al);
                        context.SaveChanges();

                        ptpoo.Prerequisites.Add(new Prerequisite(ptpoo, poo));
                        ptpoo.Prerequisites.Add(new Prerequisite(ptpoo, bd));
                        context.Subjects.Update(ptpoo);
                        context.SaveChanges();
                    }
                }

            return host;
        }
    }
}